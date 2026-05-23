import os
import re

project_dir = r"c:\Users\Jan Javer Valery C\OneDrive\Documents\FINALS-IM-master\FINALS-IM-master\InformationManagement"

def check_regex_in_file(filepath, pattern):
    try:
        with open(filepath, "r", encoding="utf-8") as f:
            content = f.read()
    except UnicodeDecodeError:
        with open(filepath, "r", encoding="latin-1") as f:
            content = f.read()
    
    matches = re.findall(pattern, content, flags=re.IGNORECASE)
    if matches:
        print(f"Found {len(matches)} instances of '{pattern}' in {os.path.basename(filepath)}")
        for m in matches[:3]:
            print(f"  -> {m}")

for root, _, files in os.walk(project_dir):
    for file in files:
        if file.endswith(".vb"):
            filepath = os.path.join(root, file)
            # Check for missing plurals
            check_regex_in_file(filepath, r'(FROM|JOIN|INTO|UPDATE)\s+`?product`?\b(?!s|_)')
            check_regex_in_file(filepath, r'(FROM|JOIN|INTO|UPDATE)\s+`?ingredient`?\b(?!s|_)')
            check_regex_in_file(filepath, r'(FROM|JOIN|INTO|UPDATE)\s+`?order`?\b(?!s|_)')
