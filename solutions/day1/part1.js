const fs = require('fs/promises');

fs.readFile('./inputs.txt', 'utf-8').then(str => {
    console.log(str.split(/\r?\n/)
        .map(input => input.match(/\d/g) ?? [])
        .map(matches => Number((matches[0] + matches.pop())) || 0)
        .reduce((total, value) => total + value));
});
