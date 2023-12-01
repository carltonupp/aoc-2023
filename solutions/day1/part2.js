const fs = require('fs/promises');

const regex = /((?=(\d|one|two|three|four|five|six|seven|eight|nine)))/g;

const parseAsNumber = (num) => {
    switch (num) {
        case "one": return "1";
        case "two": return "2";
        case "three": return "3";
        case "four": return "4";
        case "five": return "5";
        case "six": return "6";
        case "seven": return "7";
        case "eight": return "8";
        case "nine": return "9";
        default: return num;
    }
}

const getAllDigits = (str) => [...str.matchAll(regex)].flatMap(arr => arr.filter(a => !!a));

fs.readFile('./inputs.txt', 'utf-8').then(str => {
    const result = str.split(/\r?\n/)
        .map(i => getAllDigits(i))
        .map(arr => arr.map(x => parseAsNumber(x)))
        .map(matches => Number((matches[0] + matches.pop())) || 0)
        .reduce((total, x) => total + x);
    console.log(result);
});
