import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { CupResult } from "../models/cup-result";
import { Movie } from "../models/movie";

@Injectable({ providedIn: "root" })
export class CupService {
    constructor(private readonly http: HttpClient) { }

    play(selected: Movie[]) {
        return this.http.post<CupResult>("Cup", selected);
    }
}
