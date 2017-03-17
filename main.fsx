open System
//the entered string
let orginalStr =  "//;\n9;1;8"
//split the given string to the data an the delimerter
let splitString (str:string) =
    str.Split('\n')
//get the splitter, or ',' by default
let getSplitter (str:string []) = 
    if str.Length <> 1 then
        str.[0].Split([|"//"|], StringSplitOptions.RemoveEmptyEntries).[0]
    else 
        ","
//get the data (numbers)
let getString (str:string []) =
    if str.Length <> 1 then 
        str.[1]
    else 
        str.[0]

//get the numbers from the data string
let split (splitBy:string[]) (str:string)  = 
    str.Split(splitBy, StringSplitOptions.RemoveEmptyEntries)

//get the first two numbers only
let sliceArr (start:int) (length:int) (arr:string[]) =
    if arr.Length > (start + length) then
        Array.sub arr start length
    else
        arr

//the add function
let add orginalStr =
    let str = orginalStr |> splitString |> getString
    let splitBy = [|orginalStr |> splitString |> getSplitter|]
    str
    |> split splitBy 
    |> Array.map int
    |> Array.sum


printfn "Sum is: %d" (add orginalStr)
