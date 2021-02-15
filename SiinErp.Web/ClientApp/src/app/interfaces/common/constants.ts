import { Navigation } from "./navigation";
import { HttpHeaders } from '@angular/common/http';

export interface SelectValue {
    value: any;
    text: string;
};

export class Constants {
  public static APP_LANG_DEFAULT: string = 'es';

  public static API_ENDPOINT: string = '/';

  public static MESSAGE_ROW_CREATED = 'COMMON_MESSAGE_ROW_CREATED';
  public static MESSAGE_ROW_UPDATED = 'COMMON_MESSAGE_ROW_UPDATED';
  public static MESSAGE_ROW_DELETED = 'COMMON_MESSAGE_ROW_DELETED';
  public static MESSAGE_ROW_ERROR = 'COMMON_MESSAGE_ROW_ERROR';

  public static HTTP_OPTIONS: any = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  public static ROW_STATUS: SelectValue[] = [
      {value: 'A', text: 'COMMON_MESSAGE_STATUS_ACTIVE'},
      {value: 'I', text: 'COMMON_MESSAGE_STATUS_INACTIVE'}
  ];

  public static NAV_ITEMS: Navigation[] = [
    {
      displayName: 'MENU_HOME', iconName: 'home', route: '', children: []
    },
    {
      displayName: 'MENU_GENERAL',
      iconName: 'settings',
      route: 'general',
      children: [
        { displayName: 'MENU_GENERAL_VALUE_LIST', iconName: 'list', route: 'general/value-list', children: [] },
        { displayName: 'MENU_GENERAL_COUNTRY', iconName: 'language', route: 'general/country', children: [] },
        { displayName: 'MENU_GENERAL_STATE', iconName: 'map', route: 'general/state', children: [] },
        { displayName: 'MENU_GENERAL_CITY', iconName: 'place', route: 'general/city', children: [] },
      ]
    },
    {
      displayName: 'MENU_TEST',
      iconName: 'science',
      route: 'test',
      children: [
        { displayName: 'MENU_TEST_DASHBOARD', iconName: 'dashboard', route: 'test/dashboard', children: [] },
        { displayName: 'MENU_TEST_DRAG_DROP', iconName: 'drag_indicator', route: 'test/drag-drop', children: [] },
        { displayName: 'MENU_TEST_FORM', iconName: 'dynamic_form', route: 'test/form', children: [] },
        { displayName: 'MENU_TEST_TABLE', iconName: 'table_view', route: 'test/table', children: [] },
        { displayName: 'MENU_TEST_TREE', iconName: 'account_tree', route: 'test/tree', children: [] }
      ]
    }
  ];
}