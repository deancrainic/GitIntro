interface IPrint {
    print(): string;
}

class Property {
    #name: string;
    #price: number;

    constructor(name: string, price: number) {
        this.#name = name;
        this.#price = price;
    }

    getName(): string {
        return this.#name;
    }

    getPrice(): number {
        return this.#price;
    }
}

class User implements IPrint {
    email: string;
    password: string;
    age: number;
    property?: Property;

    constructor(email: string, password: string, age: number, property?: Property) {
        this.email = email;
        this.password = password;
        this.age = age;
        this.property = property;
    }

    print(): string {
        return this.email + ", " + this.password + ", " + this.age + ", " + this.property.getName() + ": " + this.property.getPrice(); 
    }
}

let property1: Property = new Property("property1", 250);
let user1: User = new User("dean.crainic@gmail.com", "1234", 21, property1);

function printUser(user: User): void {
    console.log(user.print());
}

printUser(user1);

class Repository<T> {
    array: T[];

    constructor(array: T[]) {
        this.array = array;
    }

    addItem(item: T): void {
        this.array.push(item);
    }

    removeItem(item: T): boolean {
        let index: number = this.array.indexOf(item);

        if (index == -1)
            return false;

        this.array.splice(index, index);
        return true;
    }

    indexOf(item: T): number {
        return this.array.indexOf(item);
    }

    printItems(): void {
        this.array.forEach(item => console.log(item));
    }
}

let userArray: User[] = [];
let userRepository: Repository<User> = new Repository(userArray);

userRepository.addItem(user1);
userRepository.addItem(new User("anamagehar@gmail.com", "2331", 20));

userRepository.printItems();