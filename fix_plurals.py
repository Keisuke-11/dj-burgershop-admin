import os
import re

project_dir = r"c:\Users\Jan Javer Valery C\OneDrive\Documents\FINALS-IM-master\FINALS-IM-master\InformationManagement"

def replace_regex_in_file(filepath, pattern, replacement):
    try:
        with open(filepath, "r", encoding="utf-8") as f:
            content = f.read()
        enc = "utf-8"
    except UnicodeDecodeError:
        with open(filepath, "r", encoding="latin-1") as f:
            content = f.read()
        enc = "latin-1"
    
    new_content = re.sub(pattern, replacement, content, flags=re.IGNORECASE)
    if new_content != content:
        count = len(re.findall(pattern, content, flags=re.IGNORECASE))
        with open(filepath, "w", encoding=enc) as f:
            f.write(new_content)
        print(f"Replaced {count} instances in {os.path.basename(filepath)}")

for root, _, files in os.walk(project_dir):
    for file in files:
        if file.endswith(".vb"):
            filepath = os.path.join(root, file)
            replace_regex_in_file(filepath, r'\borderdetail\b', 'orderdetails')
            replace_regex_in_file(filepath, r'\buser_account\b', 'user_accounts')
            replace_regex_in_file(filepath, r'\bproduct\b', 'products')
            replace_regex_in_file(filepath, r'\bingredient\b', 'ingredients')
            replace_regex_in_file(filepath, r'\b(?<!\w)order(?!\w)', 'orders') # be careful with order by
            replace_regex_in_file(filepath, r'\bcustomer\b', 'customers')
            replace_regex_in_file(filepath, r'\breservation_item\b', 'reservation_items')
            replace_regex_in_file(filepath, r'\bproduct_ingredient\b', 'product_ingredients')
            replace_regex_in_file(filepath, r'\binventory_batch\b', 'inventory_batches')
            replace_regex_in_file(filepath, r'\bactivity_log\b', 'activity_logs')
            replace_regex_in_file(filepath, r'\bsales_receipt\b', 'sales_receipts')
            replace_regex_in_file(filepath, r'\breceipt_item\b', 'receipt_items')
