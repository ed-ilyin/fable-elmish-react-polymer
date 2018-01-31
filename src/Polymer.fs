module Polymer

open Fable.Helpers.React


let inline paperButton b c = domEl "paper-button" b c
let inline paperSpinner b c = domEl "paper-spinner" b c


type Attribute =
    | Active
    | Raised
    interface Props.IHTMLProp
