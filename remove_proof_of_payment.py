import os

project_dir = r"c:\Users\Jan Javer Valery C\OneDrive\Documents\FINALS-IM-master\FINALS-IM-master\InformationManagement"

def remove_proof_of_payment():
    old1 = 'Dim proofPath As String = If(row.Cells("ProofOfPayment").Value?.ToString(), "")'
    new1 = 'Dim proofPath As String = ""'
    
    old2 = 'Dim receiptFileName As String = If(row.Cells("ReceiptFileName").Value?.ToString(), "")'
    new2 = 'Dim receiptFileName As String = ""'
    
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
                new_content = new_content.replace(old1, new1)
                new_content = new_content.replace(old2, new2)
                
                if new_content != content:
                    with open(filepath, "w", encoding=enc) as f:
                        f.write(new_content)
                    print(f"Fixed ProofOfPayment in {file}")

remove_proof_of_payment()
