import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { Navigation } from './interfaces/common/navigation';
import { Constants } from './interfaces/common/constants';
import { TranslateService } from './services/common/translate.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  selected = Constants.APP_LANG_DEFAULT;

  navItems: Navigation[] = Constants.NAV_ITEMS;

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver, private translate: TranslateService) { }

  onChange() {
    this.translate.use(this.selected);
  }
}