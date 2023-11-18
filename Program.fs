let rec read_all_files l =
    match l with
    | [] -> []
    | [x] -> [ System.IO.File.ReadAllText(x) ]
    | h::t ->  [ System.IO.File.ReadAllText(h) ] @ read_all_files t

let rec print_list l = 
    match l with
    | [] -> printf ""
    | [x] -> printf "%s" x
    | h::t -> printf "%s" h ; print_list t

let remove_first a = 
    match a with
    | _::t -> Some t
    | [] -> None

let () = 
    let args = System.Environment.GetCommandLineArgs() in
    let a =  List.init args.Length (Array.get args) |> remove_first in
    let t = 
        match a with
        | Some x -> x
        | None -> printfn "Yeah there are no files"; [] in
    let text = read_all_files t in
    print_list text

