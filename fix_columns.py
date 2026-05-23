import os
import re

project_dir = r"c:\Users\Jan Javer Valery C\OneDrive\Documents\FINALS-IM-master\FINALS-IM-master\InformationManagement"

def fix_columns():
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
                
                # Replace EventTime with ReservationTime
                new_content = new_content.replace('EventTime', 'ReservationTime')
                
                # Replace EventDate with ReservationDate
                # BE CAREFUL: "ReservationDate, ReservationDate" might happen in SELECT or GROUP BY
                new_content = new_content.replace('EventDate', 'ReservationDate')
                
                # Fix double ReservationDate in GROUP BY or SELECT (e.g., r.ReservationDate, r.ReservationDate)
                new_content = re.sub(r'r\.ReservationDate\s*,\s*r\.ReservationDate', 'r.ReservationDate', new_content)
                new_content = re.sub(r'ReservationDate\s*,\s*ReservationDate', 'ReservationDate', new_content)

                # Fix o.DeliveryOption in Orders.vb
                new_content = new_content.replace('o.DeliveryOption,', 'NULL AS DeliveryOption,')
                new_content = new_content.replace('COALESCE(o.DeliveryOption, \'\') AS DeliveryOption,', 'NULL AS DeliveryOption,')
                
                if new_content != content:
                    with open(filepath, "w", encoding=enc) as f:
                        f.write(new_content)
                    print(f"Fixed columns in {file}")

fix_columns()
