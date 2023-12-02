open System.Text.RegularExpressions

let inputs = List.ofSeq(System.IO.File.ReadLines "./solutions/day2/inputs.txt")

let getTotal lines =
    lines
    |> List.fold (fun total (n, _) -> total * n) 1
    

let total= [ for input in inputs do
                        [ for m in Regex.Matches(input, @"\d{1,} \w{1,}") do 
                            m.Value.Split(" ") |> fun pair -> (pair[0] |> int, pair[1]) ]
                            |> List.groupBy (fun (number, color) -> color )
                            |> List.map (fun (group, results) -> List.maxBy (fun (number, color) -> number) results)
                            |> getTotal ] |> List.sum