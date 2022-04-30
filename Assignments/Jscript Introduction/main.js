let someIntNr = 2;
let someFloatNr = 2.45;
let someString = "myString";
let someBool = true;
let someBook = {
    title: "Nietzsche's Wept",
    author: "Irvin Yalom",
    publicationYear: 1992
};
let someCars = ["BMW", "Audi", "Dacia"];
let someRandomArray = [2, "stuff", 44, someBook];

console.log(someIntNr.toLocaleString());
console.log(someIntNr);

console.log(someFloatNr);
console.log(someFloatNr.toFixed());

console.log(someString);
console.log(someString.concat(" + newString"));
console.log(someString.endsWith("ng"));
console.log(someString.length);
console.log(someString.repeat(3));
console.log(someString.replace("ng", "gn"));
console.log(someString.substring(3, 6));

console.log(someBook.title);
console.log(someBook);

console.log(someCars.every(x => x.length <= 5));
console.log(someCars);
console.log(someCars.fill("Mercedes", 1));
console.log(someCars.concat("Audi", "Seat"));
console.log(someCars.filter(x => x.startsWith("B")));
console.log(someCars.pop());
console.log(someCars.length);
console.log(someCars.slice());
console.log(someCars.shift());
console.log(someCars.unshift("Dacia", "BMW", "Seat"));
console.log(someCars.sort());

console.log(someRandomArray);

let someStringNr = "2.45";

console.log(someStringNr == someFloatNr);
console.log(someStringNr === someFloatNr);
console.log(someIntNr == someFloatNr);
console.log(someIntNr === someFloatNr);
console.log(someFloatNr === 2.45)