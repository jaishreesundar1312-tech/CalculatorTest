import { CommonModule } from '@angular/common';
import {
  Component,
  EventEmitter,
  HostListener,
  Input,
  Output,
} from '@angular/core';

/**
 * Generic, accessible modal dialog with a distinct header, body and footer.
 * Appearance is driven entirely by CSS custom properties so the host page
 * can re-style it at runtime (challenge requirement 9).
 */
@Component({
  selector: 'app-modal',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './modal.component.html',
  styleUrl: './modal.component.scss',
})
export class ModalComponent {
  @Input() open = false;
  @Input() title = 'Dialog';
  @Output() closed = new EventEmitter<void>();

  @HostListener('document:keydown.escape')
  onEscape(): void {
    if (this.open) {
      this.close();
    }
  }

  close(): void {
    this.closed.emit();
  }

  onBackdropClick(event: MouseEvent): void {
    // Only close when the backdrop itself (not its children) is clicked.
    if (event.target === event.currentTarget) {
      this.close();
    }
  }
}
