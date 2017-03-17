open System
let str = "" 
let splitBy = ","
let split (splitBy:string) (str:string)  = 
    str.Split([|splitBy|], StringSplitOptions.RemoveEmptyEntries)

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
    |> sliceArr 0 2
    |> Array.map int
    |> Array.sum


printfn "Sum is: %d" (add str)
