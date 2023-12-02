open System.Text.RegularExpressions

// let inputs =
//     [ "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"
//       "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue"
//       "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red"
//       "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red"
//       "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green" ]

let inputs = List.ofSeq(System.IO.File.ReadLines "./solutions/day2/inputs.txt")

type Game = {
    Id: int
    Pairs: (int * string) list
}

let parsePair (pair: string array) =
    (pair[0] |> int, pair[1])

let parseGameId game = 
    let idMatch = Regex.Match (game, @"\d{1,}")
    match idMatch.Success with
    | true -> idMatch.Value |> int
    | _ -> 0

let parseGame game =
    let gameId = game |> parseGameId
    let matches = Regex.Matches(game, @"\d{1,} \w{1,}")
    let pairs = [ for m in matches do m.Value.Split(" ") |> parsePair ]
    { Id = gameId; Pairs = pairs }

let pairIsValid (number, color) =
    match color with
    | "red" -> number <= 12
    | "green" -> number <= 13
    | "blue" -> number <= 14
    | _ -> false

let gameIsValid game =
    game.Pairs |> List.forall pairIsValid
    

let validGamesIdTotal = inputs 
                        |> List.map parseGame 
                        |> List.filter gameIsValid
                        |> List.sumBy _.Id


