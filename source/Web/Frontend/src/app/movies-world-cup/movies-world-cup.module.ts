import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { SharedModule } from "../shared/shared.module";
import { MoviesWorldCupComponent } from "./movies-world-cup.component";
import { MoviesWorldCupResultComponent } from "./result/result.component";
import { MoviesWorldCupSelectionComponent } from "./selection/selection.component";

const routes: Routes = [
    {
        children: [
            { path: "", pathMatch: "full", redirectTo: "selection" },
            { path: "result", component: MoviesWorldCupResultComponent },
            { path: "selection", component: MoviesWorldCupSelectionComponent }
        ],
        component: MoviesWorldCupComponent,
        path: ""
    }
];

@NgModule({
    declarations: [
        MoviesWorldCupComponent,
        MoviesWorldCupResultComponent,
        MoviesWorldCupSelectionComponent
    ],
    imports: [
        RouterModule.forChild(routes),
        SharedModule
    ]
})
export class MoviesWorldCupModule { }
