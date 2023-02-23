#!/usr/bin/env python3

from cryptography.fernet import Fernet
import os

class password_manager:

    print("Manager start")

    separator = " | "
    
    def run():
        user_input = input("Your input : ")
        if user_input == "add":
            password_manager.add()
        elif user_input == "access":
            password_manager.access()
        elif user_input == "clear":
            password_manager.clear()
        elif user_input == "q" or user_input == "quit":
            print("Manager stop")
            return
        else: 
            print("Invalid input"), help()
            
        password_manager.run()
    
    def add():
        print("Please add a new password with your")
        id = input("Id : ")
        password = input("Password : ")

        password_manager.write_key(id)
        password_manager.fernet = Fernet(password_manager.load_key(id))

        with open(".passwords", "a") as file:
            file.write(id + password_manager.separator + password_manager.fernet.encrypt(password.encode()).decode() + "\n")
        
        print("Custom key has been written to ." + id + ".key file")

    def access():
        access_id = input("Who : ")
        key = password_manager.load_key(access_id)
        password_manager.fernet = Fernet(key) if key is not None else None
        
        if password_manager.fernet is None: return
        
        with open(".passwords", "r") as file:
            for line in file.readlines(): 
                data = line.rstrip()
                id, password = data.split(password_manager.separator)
                if id == access_id: print("Id : ", id, "\nPassword :", password_manager.fernet.decrypt(password.encode()).decode())

    def clear():
        dir_list = os.listdir(".")

        for item in dir_list:
            if item.endswith(".key"):
                os.remove(os.path.join(".", item))
        os.remove(os.path.join(".", ".passwords"))
    
    def write_key(id):
        key = Fernet.generate_key()
        
        with open("." + id + ".key", "wb") as key_file:
            key_file.write(key)

    def load_key(id):
        if os.path.exists("." + id + ".key"):
            file = open("." + id + ".key", "rb")
            key = file.read()
            file.close()
            return key
        print("key file not found")

def help():
    print("\tadd - add a password\n\taccess - access a password\n\tq, quit - leave the program")

def main():
    password_manager.run()

if __name__ == "__main__":
    main()
