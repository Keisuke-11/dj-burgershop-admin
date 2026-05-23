import os
import re

project_dir = r"c:\Users\Jan Javer Valery C\OneDrive\Documents\FINALS-IM-master\FINALS-IM-master\InformationManagement"

def replace_sql_table_names(filepath):
    try:
        with open(filepath, "r", encoding="utf-8") as f:
            content = f.read()
        enc = "utf-8"
    except UnicodeDecodeError:
        with open(filepath, "r", encoding="latin-1") as f:
            content = f.read()
        enc = "latin-1"
    
    new_content = content
    
    # We only want to replace words if they are preceded by FROM, JOIN, INTO, UPDATE, TABLE
    keywords = ["orderdetail", "user_account", "product", "ingredient", "order", "customer", 
                "reservation_item", "product_ingredient", "inventory_batch", "activity_log", 
                "sales_receipt", "receipt_item"]
    
    for kw in keywords:
        pattern = r'(FROM|JOIN|INTO|UPDATE)\s+`?' + kw + r'`?\b(?!s|_)'
        new_content = re.sub(pattern, lambda m: m.group(0).replace(kw, kw + 's'), new_content, flags=re.IGNORECASE)

    if new_content != content:
        with open(filepath, "w", encoding=enc) as f:
            f.write(new_content)
        print(f"Fixed tables in {os.path.basename(filepath)}")

for root, _, files in os.walk(project_dir):
    for file in files:
        if file.endswith(".vb"):
            filepath = os.path.join(root, file)
            replace_sql_table_names(filepath)
