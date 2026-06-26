import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ModalComponent } from './modal/modal.component';
import { CalculatorService } from './services/calculator.service';

type Operation = 'add' | 'subtract';

interface ThemeSettings {
  headerBg: string;
  headerText: string;
  bodyBg: string;
  bodyText: string;
  footerBg: string;
  radius: number;
}

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule, ModalComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  modalOpen = false;

  start = 0;
  amount = 0;
  operation: Operation = 'add';

  result: number | null = null;
  error: string | null = null;
  loading = false;

  // Live-editable theme for the modal (requirement 9).
  theme: ThemeSettings = {
    headerBg: '#4f46e5',
    headerText: '#ffffff',
    bodyBg: '#ffffff',
    bodyText: '#1a1a1a',
    footerBg: '#f3f4f6',
    radius: 12,
  };

  constructor(private readonly calculator: CalculatorService) {}

  openModal(): void {
    this.result = null;
    this.error = null;
    this.modalOpen = true;
  }

  closeModal(): void {
    this.modalOpen = false;
  }

  calculate(): void {
    this.loading = true;
    this.error = null;
    this.result = null;

    const op$ =
      this.operation === 'add'
        ? this.calculator.add(this.start, this.amount)
        : this.calculator.subtract(this.start, this.amount);

    op$.subscribe({
      next: (res) => {
        this.result = res.result;
        this.loading = false;
      },
      error: (err) => {
        this.error =
          err?.error?.error ??
          'Could not reach the calculator service. Is the API running on http://localhost:5000?';
        this.loading = false;
      },
    });
  }

  // Build the inline CSS-variable style object consumed by the modal host.
  get themeVars(): Record<string, string> {
    return {
      '--modal-header-bg': this.theme.headerBg,
      '--modal-header-text': this.theme.headerText,
      '--modal-bg': this.theme.bodyBg,
      '--modal-text': this.theme.bodyText,
      '--modal-footer-bg': this.theme.footerBg,
      '--modal-radius': `${this.theme.radius}px`,
    };
  }
}
