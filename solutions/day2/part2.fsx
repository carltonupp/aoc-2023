open System.Text.RegularExpressions

let inputs = List.ofSeq(System.IO.File.ReadLines "./solutions/day2/inputs.txt")

let totals= [ for input in inputs do
                            let matches = Regex.Matches(input, @"\d{1,} \w{1,}")
                            let pairs = [ for m in matches do m.Value.Split(" ") |> fun pair -> (pair[0] |> int, pair[1]) ]

                            let grouped = pairs |> List.groupBy (fun (number, color) -> color )
                            let highestInEachGroup = grouped 
                                                                        |> List.map (fun (group, results) -> List.maxBy (fun (number, color) -> number) results)
                            let mutable total = 1
                            for (number, color) in highestInEachGroup do
                                total <- total * number

                            total ]

totals |> List.sum