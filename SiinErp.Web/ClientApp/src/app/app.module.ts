import { DragDropModule } from "@angular/cdk/drag-drop";
import { LayoutModule } from "@angular/cdk/layout";
import { HttpClientModule } from "@angular/common/http";
import { NgModule, APP_INITIALIZER } from "@angular/core";
import { FlexLayoutModule } from "@angular/flex-layout";
import { ReactiveFormsModule } from "@angular/forms";
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatBadgeModule } from '@angular/material/badge';
import { MatBottomSheetModule } from '@angular/material/bottom-sheet';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatChipsModule } from '@angular/material/chips';
import { MatStepperModule } from '@angular/material/stepper';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatDialogModule } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatNativeDateModule, MatRippleModule } from '@angular/material/core';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatSliderModule } from '@angular/material/slider';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatTreeModule } from '@angular/material/tree';
import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { Constants } from "./interfaces/common/constants";
import { MenuComponent } from "./layout/menu/menu.component";
import { HomeComponent } from "./pages/common/home/home.component";
import { CityDialogComponent } from "./pages/general/city-dialog/city-dialog.component";
import { CityComponent } from "./pages/general/city/city.component";
import { CountryDialogComponent } from "./pages/general/country-dialog/country-dialog.component";
import { CountryComponent } from "./pages/general/country/country.component";
import { StateDialogComponent } from "./pages/general/state-dialog/state-dialog.component";
import { StateComponent } from "./pages/general/state/state.component";
import { ValueListDialogComponent } from "./pages/general/value-list-dialog/value-list-dialog.component";
import { ValueListComponent } from "./pages/general/value-list/value-list.component";
import { DashboardTestComponent } from "./pages/test/dashboard-test/dashboard-test.component";
import { DragDropTestComponent } from "./pages/test/drag-drop-test/drag-drop-test.component";
import { FormTestComponent } from "./pages/test/form-test/form-test.component";
import { TableTestComponent } from "./pages/test/table-test/table-test.component";
import { TreeTestComponent } from "./pages/test/tree-test/tree-test.component";
import { NavigationService } from "./services/common/navigation.service";
import { TranslatePipe } from "./services/common/translate.pipe";
import { TranslateService } from "./services/common/translate.service";

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    HomeComponent,
    DashboardTestComponent,
    DragDropTestComponent,
    FormTestComponent,
    TableTestComponent,
    TranslatePipe,
    TreeTestComponent,
    ValueListComponent,
    ValueListDialogComponent,
    CountryComponent,
    CountryDialogComponent,
    StateComponent,
    StateDialogComponent,
    CityComponent,
    CityDialogComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    DragDropModule,
    FlexLayoutModule,
    HttpClientModule,
    MatAutocompleteModule,
    MatBadgeModule,
    MatBottomSheetModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatStepperModule,
    MatDatepickerModule,
    MatDialogModule,
    MatDividerModule,
    MatExpansionModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRadioModule,
    MatRippleModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
    MatTreeModule,
    LayoutModule,
    ReactiveFormsModule
  ],
  entryComponents: [
    ValueListDialogComponent,
    CountryDialogComponent,
    StateDialogComponent,
    CityDialogComponent
  ],
  providers: [
    NavigationService,
    TranslateService,
    {
      provide: APP_INITIALIZER,
      useFactory: setupTranslateFactory,
      deps: [ TranslateService ],
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function setupTranslateFactory(service: TranslateService): Function {
  return () => service.use(Constants.APP_LANG_DEFAULT);
}