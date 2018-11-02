import { Routes } from "@angular/router";
import { LayoutComponent } from "./shared/layout/layout.component";

export const routes: Routes = [
    {
        children: [
            { path: "", pathMatch: "full", redirectTo: "movies-world-cup" },
            { path: "movies-world-cup", loadChildren: "./movies-world-cup/movies-world-cup.module#MoviesWorldCupModule" }
        ],
        component: LayoutComponent,
        path: ""
    },

    { path: "**", redirectTo: "" }
];
