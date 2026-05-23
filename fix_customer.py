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
    
    # We want to revert customers back to customer
    # Be careful to only change it where it was likely a table name
    pattern = r'(FROM|JOIN|INTO|UPDATE)\s+`?customers`?\b'
    new_content = re.sub(pattern, lambda m: m.group(0).replace('customers', 'customer'), new_content, flags=re.IGNORECASE)

    if new_content != content:
        with open(filepath, "w", encoding=enc) as f:
            f.write(new_content)
        print(f"Fixed customers -> customer in {os.path.basename(filepath)}")

for root, _, files in os.walk(project_dir):
    for file in files:
        if file.endswith(".vb"):
            filepath = os.path.join(root, file)
            replace_sql_table_names(filepath)
