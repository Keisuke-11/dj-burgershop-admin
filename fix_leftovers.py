import os

project_dir = r"c:\Users\Jan Javer Valery C\OneDrive\Documents\FINALS-IM-master\FINALS-IM-master\InformationManagement"

for root, _, files in os.walk(project_dir):
    for file in files:
        if file.endswith(".vb"):
            filepath = os.path.join(root, file)
            try:
                with open(filepath, "r", encoding="utf-8") as f:
                    content = f.read()
                enc = "utf-8"
            except UnicodeDecodeError:
                with open(filepath, "r", encoding="latin-1") as f:
                    content = f.read()
                enc = "latin-1"
            
            # Simple string replacements to catch any leftovers
            reps = [
                ("FROM order ", "FROM orders "),
                ("FROM `order` ", "FROM `orders` "),
                ("JOIN order ", "JOIN orders "),
                ("INTO order ", "INTO orders "),
                ("UPDATE order ", "UPDATE orders "),
                ("FROM order\n", "FROM orders\n"),
                ("FROM order\r", "FROM orders\r"),
                ("FROM order\"", "FROM orders\""),
                ("FROM order WHERE", "FROM orders WHERE")
            ]
            
            new_content = content
            for old, new in reps:
                new_content = new_content.replace(old, new)
            
            if new_content != content:
                with open(filepath, "w", encoding=enc) as f:
                    f.write(new_content)
                print(f"Fixed string matches in {file}")
