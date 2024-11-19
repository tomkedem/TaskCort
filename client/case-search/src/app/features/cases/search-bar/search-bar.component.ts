import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-search-bar',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.scss'],
})
export class SearchBarComponent {
  @Output() searchChanged = new EventEmitter<string>();
  @Output() filterChanged = new EventEmitter<string>();

  searchValue: string = '';
  filterStatus: string = 'All'; // Default filter status

  // Emit the search value to the parent component
  onSearch(): void {
    this.searchChanged.emit(this.searchValue);
  }

  // Emit the filter status to the parent component
  onFilterChange(status: string): void {
    this.filterStatus = status;
    this.filterChanged.emit(status);
  }
}
