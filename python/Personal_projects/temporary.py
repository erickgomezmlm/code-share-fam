def main():
    print(f"\n\nWelcome to this useless adder!")
    userin= input(f"Type in two number that you would like to add: ")
    we_added = convert_srting(userin)

    print(f"\nIf you add those to numbers you get!: {int(we_added)}\n\n")
    print("This is super usefull right?????")

def convert_srting(userin):
    nums_list = userin.split(" ")
    math = float(nums_list[0]) + float(nums_list[1])
    return math

        
        
        

main()