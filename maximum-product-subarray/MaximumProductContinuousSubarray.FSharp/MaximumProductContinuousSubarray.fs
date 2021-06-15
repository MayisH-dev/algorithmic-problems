module MaximumProductContinuousSubarray.FSharp
    let public maxProduct (nums : int array) =
        let runningProductExtrema (maxTilHere, minTilHere, currentMax) this =
            let newMax = max this (maxTilHere * this) |> max (minTilHere * this)
            let newMin = min this (maxTilHere * this) |> min (minTilHere * this)
            ( newMax, newMin, max newMax currentMax )

        nums
        |> Seq.ofArray
        |> Seq.tail
        |> Seq.fold runningProductExtrema (nums.[0], nums.[0], nums.[0])
        |> fun (_, _, max) -> max