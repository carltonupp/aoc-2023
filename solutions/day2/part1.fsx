open System.Text.RegularExpressions

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


