import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { State } from 'src/app/interfaces/general/state';
import { StateService } from 'src/app/services/general/state.service';
import { StateDialogComponent } from '../state-dialog/state-dialog.component';

const dialogSize: string = '650px';

@Component({
  selector: 'app-state',
  templateUrl: './state.component.html',
  styleUrls: ['./state.component.scss']
})
export class StateComponent implements OnInit {
  /**
   * Array for defining visible columns of the DataTable
   */
  displayedColumns = ['stateCode', 'stateName', 'country', 'actions'];
  /**
   * Object for handling the DataSource of the DataTable
   */
  dataSource: MatTableDataSource<State>;
  /**
   * Object for handling Pagination of the DataTable
   */
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  /**
   * Object for managing DataTable Sorting
   */
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  /**
   * Component constructor
   * @param mainService StateService service injection
   * @param dialog MatDialog class injection
   */
  constructor(
    private mainService: StateService,
    public dialog: MatDialog) { }

  /**
   * Start method after component construction
   */
  ngOnInit(): void {
    this.getAll();
  }

  /**
   * Method to apply filters on the DataTable
   * @param event Filter value
   */
  applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  /**
   * Method that call the creation Dialog component 
   */
  openNewDialog(): void {
    const dialogRef = this.dialog.open(StateDialogComponent, {
      width: dialogSize,
      data: { create: true }
    });

    dialogRef.afterClosed().subscribe(result => {
      this.getAll();
    });
  }

  /**
   * Method that call the update Dialog component 
   * @param obj Object to be modified
   */
  openEditDialog(obj: State): void {
    const dialogRef = this.dialog.open(StateDialogComponent, {
      width: dialogSize,
      data: { create: false, data: obj }
    });

    dialogRef.afterClosed().subscribe(result => {
      this.getAll();
    });
  }

  /**
   * Method to get all the objects of the entity
   */
  getAll(): void {
    this.mainService.getAll()
      .subscribe((res: any) => {
        this.dataSource = new MatTableDataSource(res);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      }, err => {
        console.error(err);
      });
  }
}