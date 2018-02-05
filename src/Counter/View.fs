module Counter.View

open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Polymer


importAll "../../bower_components/paper-button/paper-button.html"
importAll "../../bower_components/paper-styles/color.html"
importAll "../../bower_components/paper-styles/typography.html"


let simpleButton txt action dispatch =
    paperButton [
        // ClassName "column is-narrow button"
        Raised true
        Style [
            BackgroundColor "var(--paper-green-700)"
            Color "white"
        ]
        OnClick (fun _ -> action |> dispatch)
    ] [ str txt ]


let root model dispatch =
  div
    [ ClassName "columns is-vcentered" ]
    [ div [ ClassName "column" ] [ ]
      div
        [ ClassName "column is-narrow"
          Style
            [ CSSProp.Width "170px" ] ]
        [ str (sprintf "Counter value: %i" model) ]
      simpleButton "+1" Increment dispatch
      simpleButton "-1" Decrement dispatch
      simpleButton "Reset" Reset dispatch
      div [ ClassName "column" ] [ ] ]
