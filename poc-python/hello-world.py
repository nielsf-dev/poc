import subprocess


# useless_cat_call = subprocess.run(["java", "--version"], stdout=subprocess.PIPE, text=True)
# print(useless_cat_call.stdout)

def vet_dik_gaan():
    print("doen")
    print("durven")
    print("yooooolo")

vet_dik_gaan()
useless_cat_call = subprocess.run(["java", "--version"])
print(useless_cat_call.stdout)

some_input = input("Please enter an integer: ")
x = int(some_input)
print('Hello, world!' + str(x))
