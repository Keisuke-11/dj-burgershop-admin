import os
import re

project_dir = r"c:\Users\Jan Javer Valery C\OneDrive\Documents\FINALS-IM-master\FINALS-IM-master\InformationManagement"

def update_categories():
    old_list1 = '"SPAGHETTI MEAL", "DESSERT", "DRINKS & BEVERAGES", "PLATTER", "RICE MEAL", "RICE", "Bilao", "Snacks"'
    new_list = '"Burgers", "Sides", "Silog Meals", "Drinks"'
    
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
                
                new_content = content
                
                # Replace inline list
                new_content = new_content.replace(old_list1, new_list)
                
                # Replace multi-line list in MenuItems.vb
                old_multiline = """            "SPAGHETTI MEAL",
            "DESSERT",
            "DRINKS & BEVERAGES",
            "PLATTER",
            "RICE MEAL",
            "RICE",
            "Bilao",
            "Snacks\""""
                new_multiline = """            "Burgers",
            "Sides",
            "Silog Meals",
            "Drinks\""""
                new_content = new_content.replace(old_multiline, new_multiline)
                
                if new_content != content:
                    with open(filepath, "w", encoding=enc) as f:
                        f.write(new_content)
                    print(f"Updated categories in {file}")

update_categories()
