import { Injectable, signal, WritableSignal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, of } from 'rxjs';
import { Case } from '../interfaces/user.interface';

@Injectable({
  providedIn: 'root',
})
export class SearchService {
  private casesSignal: WritableSignal<Case[]> = signal<Case[]>([]);

  constructor(private http: HttpClient) {
    this.loadCases();
  }

  // Load cases from JSON file
  private loadCases(): void {
    this.http.get<Case[]>('assets/mock-cases.json').pipe(
      catchError((error) => {
        console.error('Failed to load cases', error);
        return of([]); // Return empty array in case of error
      })
    ).subscribe((cases) => this.casesSignal.set(cases)); // Use set method for WritableSignal
  }

  // Getter for cases (read-only signal)
  get getCases(): WritableSignal<Case[]> {
    return this.casesSignal;
  }

}
