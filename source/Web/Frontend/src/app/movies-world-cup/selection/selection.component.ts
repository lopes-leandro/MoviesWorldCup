import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Movie } from "../../models/movie";
import { CupService } from "../../services/cup.service";
import { MovieService } from "../../services/movie.service";
import { MoviesWorldCupService } from "../movies-world-cup.service";

@Component({ selector: "app-movies-world-cup-selection", templateUrl: "./selection.component.html" })
export class MoviesWorldCupSelectionComponent implements OnInit {
    movies: Movie[] = new Array<Movie>();
    quantityToSelect = 8;

    constructor(
        private readonly cupService: CupService,
        private readonly movieService: MovieService,
        private readonly moviesWorldCupService: MoviesWorldCupService,
        private readonly router: Router) { }

    ngOnInit(): void {
        this.listMovies();
    }

    isQuantitySelected() {
        return this.quantitySelected() === this.quantityToSelect;
    }

    listMovies() {
        this.movieService.list().subscribe((movies) => { this.movies = movies; });
    }

    listMoviesSelected() {
        return this.movies.filter((movie) => movie.selected);
    }

    quantitySelected(): number {
        return this.listMoviesSelected().length;
    }

    generateChampionship() {
        this.cupService
            .play(this.listMoviesSelected())
            .subscribe((cupResult) => {
                this.moviesWorldCupService.setCupResult(cupResult);
                this.router.navigate(["movies-world-cup/result"]);
            });
    }
}
