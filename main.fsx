open System
let str = "1,5\n6,8,9" 
let splitBy = [|","; "\n"|]
let split (splitBy:string[]) (str:string)  = 
    str.Split(splitBy, StringSplitOptions.RemoveEmptyEntries)

//get the first two numbers only
let sliceArr (start:int) (length:int) (arr:string[]) =
    if arr.Length > (start + length) then
        Array.sub arr start length
    else
        arr

//the add function
let add str =
    str
    |> split splitBy 
    |> Array.map int
    |> Array.sum


printfn "Sum is: %d" (add str)
