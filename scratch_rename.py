"""
Table name fixer for InformationManagement VB.NET project.
Renames all wrong table references to match the exact burger_system schema.
"""
import os
import re

project_dir = r"c:\Users\Jan Javer Valery C\OneDrive\Documents\FINALS-IM-master\FINALS-IM-master\InformationManagement\Admin"

changes_log = []

def replace_in_file(filepath, old, new, description=""):
    """Replace exact string old with new in file. Returns True if changed."""
    try:
        with open(filepath, "r", encoding="utf-8") as f:
            content = f.read()
        enc = "utf-8"
    except UnicodeDecodeError:
        with open(filepath, "r", encoding="latin-1") as f:
            content = f.read()
        enc = "latin-1"
    if old not in content:
        return False
    new_content = content.replace(old, new)
    if new_content != content:
        with open(filepath, "w", encoding=enc) as f:
            f.write(new_content)
        count = content.count(old)
        changes_log.append(f"  {os.path.basename(filepath)}: '{old}' -> '{new}' ({count} occurrences) [{description}]")
        return True
    return False

def replace_regex_in_file(filepath, pattern, replacement, description=""):
    """Replace regex pattern in file. Returns True if changed."""
    try:
        with open(filepath, "r", encoding="utf-8") as f:
            content = f.read()
        enc = "utf-8"
    except UnicodeDecodeError:
        with open(filepath, "r", encoding="latin-1") as f:
            content = f.read()
        enc = "latin-1"
    new_content = re.sub(pattern, replacement, content)
    if new_content != content:
        count = len(re.findall(pattern, content))
        with open(filepath, "w", encoding=enc) as f:
            f.write(new_content)
        changes_log.append(f"  {os.path.basename(filepath)}: regex '{pattern[:60]}...' ({count} occurrences) [{description}]")
        return True
    return False

# Collect all .vb files
vb_files = []
for f in os.listdir(project_dir):
    if f.endswith(".vb"):
        vb_files.append(os.path.join(project_dir, f))

print(f"Found {len(vb_files)} .vb files to scan")
print("=" * 60)

# ===================================================================
# PASS 1: Fix table names with exact string replacements
# These are safe because they appear in SQL string contexts
# ===================================================================
print("\n--- PASS 1: Table name fixes ---")

for filepath in vb_files:
    fname = os.path.basename(filepath)
    
    # --- `order` -> `orders` (backticked) ---
    replace_in_file(filepath, "FROM `order`", "FROM `orders`", "order->orders")
    replace_in_file(filepath, "JOIN `order`", "JOIN `orders`", "order->orders")
    replace_in_file(filepath, "INTO `order`", "INTO `orders`", "order->orders")
    replace_in_file(filepath, "UPDATE `order`", "UPDATE `orders`", "order->orders")
    
    # --- product_ingredient -> product_ingredients ---
    replace_in_file(filepath, "FROM product_ingredient ", "FROM product_ingredients ", "pi table")
    replace_in_file(filepath, "FROM product_ingredient\n", "FROM product_ingredients\n", "pi table")
    replace_in_file(filepath, "JOIN product_ingredient ", "JOIN product_ingredients ", "pi table")
    replace_in_file(filepath, "INTO product_ingredient ", "INTO product_ingredients ", "pi table")
    replace_in_file(filepath, "INTO product_ingredient(", "INTO product_ingredients(", "pi table")
    replace_in_file(filepath, "UPDATE product_ingredient ", "UPDATE product_ingredients ", "pi table")
    replace_in_file(filepath, "DELETE FROM product_ingredient ", "DELETE FROM product_ingredients ", "pi table")
    
    # --- reservation_item -> reservation_items ---
    replace_in_file(filepath, "FROM reservation_item ", "FROM reservation_items ", "res_item table")
    replace_in_file(filepath, "FROM reservation_item\n", "FROM reservation_items\n", "res_item table")
    replace_in_file(filepath, "FROM reservation_item\"", "FROM reservation_items\"", "res_item table")
    replace_in_file(filepath, "JOIN reservation_item ", "JOIN reservation_items ", "res_item table")
    replace_in_file(filepath, "INTO reservation_item ", "INTO reservation_items ", "res_item table")
    replace_in_file(filepath, "FROM reservation_item WHERE", "FROM reservation_items WHERE", "res_item table")
    
    # --- reservation_payment -> reservationpayment ---
    replace_in_file(filepath, "FROM reservation_payment ", "FROM reservationpayment ", "res_payment table")
    replace_in_file(filepath, "FROM reservation_payment\"", "FROM reservationpayment\"", "res_payment table")
    replace_in_file(filepath, "JOIN reservation_payment ", "JOIN reservationpayment ", "res_payment table")
    replace_in_file(filepath, "JOIN reservation_payments ", "JOIN reservationpayment ", "res_payment table")
    replace_in_file(filepath, "INTO reservation_payment ", "INTO reservationpayment ", "res_payment table")
    replace_in_file(filepath, "INTO reservation_payment(", "INTO reservationpayment(", "res_payment table")
    replace_in_file(filepath, "UPDATE reservation_payment ", "UPDATE reservationpayment ", "res_payment table")
    replace_in_file(filepath, "DELETE FROM reservation_payment ", "DELETE FROM reservationpayment ", "res_payment table")
    
    # --- inventory_movement_log -> inventory_movement (verify) ---
    replace_in_file(filepath, "inventory_movement_log", "inventory_movement", "inv_movement table")

# ===================================================================
# PASS 2: Fix table names using regex for SQL keyword contexts
# product -> products, ingredient -> ingredients
# These need regex to avoid replacing variable names
# ===================================================================
print("\n--- PASS 2: Regex-based table name fixes ---")

for filepath in vb_files:
    fname = os.path.basename(filepath)
    
    # product -> products (only in SQL contexts, not product_ingredients)
    # Match FROM/JOIN/INTO/UPDATE followed by "product" then space/newline/quote but NOT "product_"
    replace_regex_in_file(filepath,
        r'(FROM|JOIN|INTO|UPDATE)\s+product\b(?!s|_)',
        r'\1 products',
        "product->products")
    
    # ingredient -> ingredients (only in SQL contexts, not ingredient_categories)
    replace_regex_in_file(filepath,
        r'(FROM|JOIN|INTO|UPDATE)\s+ingredient\b(?!s|_)',
        r'\1 ingredients',
        "ingredient->ingredients")
    
    # inventory -> inventory_batches (when used as batch table with ib alias or BatchID context)
    # This is tricky - we need to identify batch usage vs finished goods usage
    # Pattern: "inventory ib" (with alias ib) is always the batches table
    replace_in_file(filepath, "FROM inventory ib", "FROM inventory_batches ib", "inventory->inventory_batches")
    replace_in_file(filepath, "JOIN inventory ib", "JOIN inventory_batches ib", "inventory->inventory_batches")
    replace_in_file(filepath, "FROM inventory \"", "FROM inventory_batches \"", "inventory->inventory_batches")
    replace_in_file(filepath, "UPDATE inventory SET BatchStatus", "UPDATE inventory_batches SET BatchStatus", "inventory->inventory_batches")
    replace_in_file(filepath, "UPDATE inventory SET StockQuantity", "UPDATE inventory_batches SET StockQuantity", "inventory->inventory_batches")
    replace_in_file(filepath, "INTO inventory_movement", "INTO inventory_movement", "keep inventory_movement") # no-op guard

# ===================================================================
# PASS 3: Fix inventory table references that use BatchID/BatchNumber
# These are definitely inventory_batches references
# ===================================================================
print("\n--- PASS 3: Inventory batch context fixes ---")

for filepath in vb_files:
    try:
        with open(filepath, "r", encoding="utf-8") as f:
            content = f.read()
        enc = "utf-8"
    except UnicodeDecodeError:
        with open(filepath, "r", encoding="latin-1") as f:
            content = f.read()
        enc = "latin-1"
    
    original = content
    
    # Fix "FROM inventory " followed by WHERE with BatchID/BatchNumber/IngredientID
    # These patterns clearly indicate the batches table
    content = re.sub(
        r'FROM inventory\s+(WHERE\s+(?:BatchID|BatchNumber|IngredientID|BatchStatus))',
        r'FROM inventory_batches \1',
        content
    )
    
    # Fix "FROM inventory" & "WHERE BatchID"
    content = re.sub(
        r'(FROM inventory)\s*("\s*&\s*\n?\s*"\s*WHERE\s+(?:BatchID|IngredientID))',
        r'FROM inventory_batches \2',
        content
    )
    
    if content != original:
        with open(filepath, "w", encoding=enc) as f:
            f.write(content)
        changes_log.append(f"  {os.path.basename(filepath)}: inventory context fixes")

# ===================================================================
# SUMMARY
# ===================================================================
print("\n" + "=" * 60)
print("CHANGES LOG:")
print("=" * 60)
for entry in changes_log:
    print(entry)
print(f"\nTotal changes: {len(changes_log)}")
