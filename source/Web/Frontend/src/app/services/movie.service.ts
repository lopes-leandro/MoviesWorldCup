import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Movie } from "../models/movie";

@Injectable({ providedIn: "root" })
export class MovieService {
    constructor(private readonly http: HttpClient) { }

    list() {
        return this.http.get<Movie[]>("Movie");
    }
}
