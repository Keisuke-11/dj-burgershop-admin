import re

filepath = r"c:\Users\Jan Javer Valery C\OneDrive\Documents\FINALS-IM-master\FINALS-IM-master\InformationManagement\Admin\Dashboard.vb"
try:
    with open(filepath, "r", encoding="utf-8") as f:
        content = f.read()
except UnicodeDecodeError:
    with open(filepath, "r", encoding="latin-1") as f:
        content = f.read()

pattern = r'(FROM|JOIN|INTO|UPDATE)\s+`?order`?\b(?!s|_)'
matches = re.findall(pattern, content, flags=re.IGNORECASE)
print(f"Matches found: {len(matches)}")
for i, m in enumerate(re.finditer(pattern, content, flags=re.IGNORECASE)):
    print(f"Match {i}: '{m.group(0)}' at {m.start()}")
