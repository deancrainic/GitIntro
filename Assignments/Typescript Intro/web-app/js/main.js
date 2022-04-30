var __classPrivateFieldSet = (this && this.__classPrivateFieldSet) || function (receiver, state, value, kind, f) {
    if (kind === "m") throw new TypeError("Private method is not writable");
    if (kind === "a" && !f) throw new TypeError("Private accessor was defined without a setter");
    if (typeof state === "function" ? receiver !== state || !f : !state.has(receiver)) throw new TypeError("Cannot write private member to an object whose class did not declare it");
    return (kind === "a" ? f.call(receiver, value) : f ? f.value = value : state.set(receiver, value)), value;
};
var __classPrivateFieldGet = (this && this.__classPrivateFieldGet) || function (receiver, state, kind, f) {
    if (kind === "a" && !f) throw new TypeError("Private accessor was defined without a getter");
    if (typeof state === "function" ? receiver !== state || !f : !state.has(receiver)) throw new TypeError("Cannot read private member from an object whose class did not declare it");
    return kind === "m" ? f : kind === "a" ? f.call(receiver) : f ? f.value : state.get(receiver);
};
var _Property_name, _Property_price;
class Property {
    constructor(name, price) {
        _Property_name.set(this, void 0);
        _Property_price.set(this, void 0);
        __classPrivateFieldSet(this, _Property_name, name, "f");
        __classPrivateFieldSet(this, _Property_price, price, "f");
    }
    getName() {
        return __classPrivateFieldGet(this, _Property_name, "f");
    }
    getPrice() {
        return __classPrivateFieldGet(this, _Property_price, "f");
    }
}
_Property_name = new WeakMap(), _Property_price = new WeakMap();
class User {
    constructor(email, password, age, property) {
        this.email = email;
        this.password = password;
        this.age = age;
        this.property = property;
    }
    print() {
        return this.email + ", " + this.password + ", " + this.age + ", " + this.property.getName() + ": " + this.property.getPrice();
    }
}
let property1 = new Property("property1", 250);
let user1 = new User("dean.crainic@gmail.com", "1234", 21, property1);
function printUser(user) {
    console.log(user.print());
}
printUser(user1);
class Repository {
    constructor(array) {
        this.array = array;
    }
    addItem(item) {
        this.array.push(item);
    }
    removeItem(item) {
        let index = this.array.indexOf(item);
        if (index == -1)
            return false;
        this.array.splice(index, index);
        return true;
    }
    indexOf(item) {
        return this.array.indexOf(item);
    }
    printItems() {
        this.array.forEach(item => console.log(item));
    }
}
let userArray = [];
let userRepository = new Repository(userArray);
userRepository.addItem(user1);
userRepository.addItem(new User("anamagehar@gmail.com", "2331", 20));
userRepository.printItems();
