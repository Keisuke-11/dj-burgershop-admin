import os
import re

proj_dir = r'c:\Users\Jan Javer Valery C\OneDrive\Documents\FINALS-IM-master\FINALS-IM-master\InformationManagement'

count_syntax_errors = 0
count_type_errors = 0

for root, _, files in os.walk(proj_dir):
    for f in files:
        if f.endswith('.vb'):
            filepath = os.path.join(root, f)
            with open(filepath, 'r', encoding='utf-8', errors='ignore') as file:
                content = file.read()
            
            orig_content = content
            
            # 1. Fix the \' syntax error
            content, n1 = re.subn(r'^\\\' ', r"' ", content, flags=re.MULTILINE)
            count_syntax_errors += n1
            
            # 2. Fix the namespace issue: change InformationManagement.RoundedPane2 to Global.InformationManagement.RoundedPane2
            content, n2 = re.subn(r'\bNew InformationManagement\.RoundedPane2\(\)', r'New Global.InformationManagement.RoundedPane2()', content)
            content, n3 = re.subn(r'\bAs InformationManagement\.RoundedPane2\b', r'As Global.InformationManagement.RoundedPane2', content)
            content, n4 = re.subn(r'CType\(([^,]+), InformationManagement\.RoundedPane2\)', r'CType(\1, Global.InformationManagement.RoundedPane2)', content)
            count_type_errors += (n2 + n3 + n4)
            
            if content != orig_content:
                with open(filepath, 'w', encoding='utf-8') as file:
                    file.write(content)

print(f'Fixed {count_syntax_errors} syntax errors and {count_type_errors} type references.')
