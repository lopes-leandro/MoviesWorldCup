import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { CupResult } from "../../models/cup-result";
import { MoviesWorldCupService } from "../movies-world-cup.service";

@Component({ selector: "app-movies-world-cup-result", templateUrl: "./result.component.html" })
export class MoviesWorldCupResultComponent implements OnInit {
    cupResult: CupResult;

    constructor(
        private readonly moviesWorldCupService: MoviesWorldCupService,
        private readonly router: Router) { }

    ngOnInit(): void {
        this.cupResult = this.moviesWorldCupService.getCupResult();

        if (!this.cupResult) {
            this.back();
        }
    }

    back() {
        this.router.navigate(["movies-world-cup/selection"]);
    }
}
