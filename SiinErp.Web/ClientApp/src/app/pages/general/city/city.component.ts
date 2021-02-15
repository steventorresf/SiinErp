import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { City } from 'src/app/interfaces/general/city';
import { CityService } from 'src/app/services/general/city.service';
import { CityDialogComponent } from '../city-dialog/city-dialog.component';

const dialogSize: string = '650px';

@Component({
  selector: 'app-city',
  templateUrl: './city.component.html',
  styleUrls: ['./city.component.scss']
})
export class CityComponent implements OnInit {
  /**
   * Array for defining visible columns of the DataTable
   */
  displayedColumns = ['cityCode', 'cityName', 'country', 'state', 'actions'];
  /**
   * Object for handling the DataSource of the DataTable
   */
  dataSource: MatTableDataSource<City>;
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
   * @param mainService CityService service injection
   * @param dialog MatDialog class injection
   */
  constructor(
    private mainService: CityService,
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
    const dialogRef = this.dialog.open(CityDialogComponent, {
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
  openEditDialog(obj: City): void {
    const dialogRef = this.dialog.open(CityDialogComponent, {
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