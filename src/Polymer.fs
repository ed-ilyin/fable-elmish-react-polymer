module Polymer

open Fable.Helpers.React


let inline appDrawer b c = domEl "app-drawer" b c
let inline appDrawerLayout b c = domEl "app-drawer-layout" b c
let inline appHeader b c = domEl "app-header" b c
let inline appHeaderLayout b c = domEl "app-header-layout" b c
let inline appToolbar b c = domEl "app-toolbar" b c
let inline paperButton b c = domEl "paper-button" b c
let inline paperIconButton b c = domEl "paper-icon-button" b c
let inline paperSpinner b c = domEl "paper-spinner" b c


type Attribute =
    | Active of bool
    | Raised of bool
    | Reveals of bool
    | Effects of string
    | Slot of string
    | ``Drawer-toggle`` of bool
    | ``Main-title``
    interface Props.IHTMLProp
