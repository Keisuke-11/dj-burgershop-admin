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
            # Find inventory_batches and replace with inventory
            replace_regex_in_file(filepath, r'\binventory_batches\b', 'inventory')
