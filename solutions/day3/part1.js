const inputs = [
    "467..114..",
    "...*......",
    "..35..633.",
    "......#...",
    "617*......",
    ".....+.58.",
    "..592.....",
    "......755.",
    "...$.*....",
    ".664.598..",
  ];
  
  const getDigitMatches = (line) =>
    [...line.matchAll(/\d{1,}/g)].map((match) => match[0]);
  
  function range(size, startAt = 0) {
    return [...Array(size).keys()].map((i) => i + startAt);
  }
  
  const isNumeric = (maybeNumber) =>
    !isNaN(parseFloat(maybeNumber) && isFinite(maybeNumber));
  
  const isSymbol = (maybeSymbol) =>
    !isNumeric(maybeSymbol) && maybeSymbol !== ".";
  
  const findNeighbours = (y, x) => {
    const grid = inputs.map((input) => input.split(""));
    const neighbours = [];
    if (y > 0) {
      const above = grid[y - 1].slice(x - 1, x + 2);
      neighbours.push(above);
    }
  
    neighbours.push(grid[y].slice(x - 1, x + 2));
  
    if (y < grid[y].length - 1) {
      const above = grid[y + 1].slice(x - 1, x + 2);
      neighbours.push(above);
    }
  
    return neighbours.flatMap((neighbours) => neighbours);
  };
  
  const slices = (index, digits) => {
    const line = inputs[index];
    return digits.map((digit) => range(digit.length, line.indexOf(digit)));
  };
  
  const indexesOfStringMatchesByLine = inputs.map((input, index) => [
    index,
    slices(index, getDigitMatches(input)),
  ]);
  
  
  function getDigitsThatHaveASymbolNeighbour(lineIndex, slices) {
      const valid = [];
      for (const slice of slices) {
          for (const idx of slice) {
              if (findNeighbours(lineIndex, idx).some(n => isSymbol(n))) {
                  valid.push([lineIndex, slice]);
                  break;
              }
          }
      }
      return valid;
  }
  
  const neighbours = indexesOfStringMatchesByLine.flatMap(([lineIndex, slices]) => getDigitsThatHaveASymbolNeighbour(lineIndex, slices));
  
  
  console.log(neighbours)
  
  const partNumbers = [];
  
  for (const [line, slices] of neighbours) {
      const [first, ...rest] = slices
      const subStr = inputs[line].substring(first, rest.pop() + 1)
  
      partNumbers.push(subStr);
  }
  
  console.log(partNumbers.map(Number).reduce((total, n) => total + n))
  
  
  
  console.log(partNumbers)