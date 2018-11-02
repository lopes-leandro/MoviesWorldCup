import { Injectable } from "@angular/core";
import { CupResult } from "../models/cup-result";

@Injectable({ providedIn: "root" })
export class MoviesWorldCupService {
    private cupResult: CupResult;

    setCupResult(cupResult: CupResult) {
        this.cupResult = cupResult;
    }

    getCupResult() {
        return this.cupResult;
    }
}
