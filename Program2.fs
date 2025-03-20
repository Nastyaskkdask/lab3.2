open System

let find (stringSeq: seq<string>) : string option =
    let shortest (a:string) (b:string) : string =
        printfn "Сравнение: '%s' vs '%s'" a b
        if a.Length <= b.Length then a
        else b

    stringSeq
    |> Seq.fold (fun acc str ->
        match acc with
        | None -> Some str
        | Some currentShortest -> Some (shortest currentShortest str)) None


let mySeq : seq<string> =
    printf "Введите строки (каждую на новой строке, пустая строка - конец ввода):\n"
    let rec readLines acc =
        match Console.ReadLine() with
        | "" -> acc
        | line -> readLines (Seq.append acc (seq { yield line }))

    readLines Seq.empty


if Seq.isEmpty mySeq then
    printfn "Список пуст. Поиск не производится."
else
    printfn "Сгенерированная последовательность строк:"
    mySeq |> Seq.iter (printfn "%s")

    match find mySeq with
    | Some shortestString -> printfn "\nСамая короткая строка: %s" shortestString
    | None -> printfn "\nСписок пуст." 

