module App.View

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Browser
open Types
open App.State
open Global
open Polymer

importAll "../styles/main.css"
// importAll "../bower_components/webcomponentsjs/webcomponents-lite.js"
importAll "../bower_components/paper-styles/typography.html"
importAll "../bower_components/app-layout/app-layout.html"
importAll "../bower_components/app-layout/app-scroll-effects/effects/waterfall.html"

open Fable.Helpers.React
open Fable.Helpers.React.Props

// let menuItem label page currentPage =
//     li
//       [ ]
//       [ a
//           [ classList [ "is-active", page = currentPage ]
//             Href (toHash page) ]
//           [ str label ] ]

// let menu currentPage =
//   aside
//     [ ClassName "menu" ]
//     [ p
//         [ ClassName "menu-label" ]
//         [ str "General" ]
//       ul
//         [ ClassName "menu-list" ]
//         [ menuItem "Home" Home currentPage
//           menuItem "Counter sample" Counter currentPage
//           menuItem "About" Page.About currentPage ] ]

let root model dispatch =

    let pageHtml =
        function
        | Page.About -> Info.View.root
        | Counter -> Counter.View.root model.counter (CounterMsg >> dispatch)
        | Home -> Home.View.root model.home (HomeMsg >> dispatch)

    appDrawerLayout [] [
        appDrawer [ Slot "drawer" ]
            [ appToolbar [] [ str "Application" ] ]
        appHeaderLayout [] [
            appHeader
                [ Slot "header"; Reveals true; Effects "waterfall" ] [
                appToolbar [] [
                    paperIconButton
                        [ Icon "menu"; ``Drawer-toggle`` true ]
                        []
                    div [ ``Main-title`` ] [ str "Title" ]
                ]
            ]
            div [ Size 100. ] [ str "My Content" ]
        ]
    ]


open Elmish.React
open Elmish.Debug
open Elmish.HMR

// App
Program.mkProgram init update root
|> Program.toNavigable (parseHash pageParser) urlUpdate
//-:cnd:noEmit
#if DEBUG
|> Program.withDebugger
|> Program.withHMR
#endif
//+:cnd:noEmit
|> Program.withReact "elmish-app"
|> Program.run
