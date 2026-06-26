import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { API_BASE_URL } from '../../environments';

export interface CalculationResult {
  start: number;
  amount: number;
  operation: string;
  result: number;
}

@Injectable({ providedIn: 'root' })
export class CalculatorService {
  private readonly baseUrl = `${API_BASE_URL}/api/calculator`;

  constructor(private readonly http: HttpClient) {}

  add(start: number, amount: number): Observable<CalculationResult> {
    return this.http.get<CalculationResult>(`${this.baseUrl}/add`, {
      params: { start, amount },
    });
  }

  subtract(start: number, amount: number): Observable<CalculationResult> {
    return this.http.get<CalculationResult>(`${this.baseUrl}/subtract`, {
      params: { start, amount },
    });
  }
}
