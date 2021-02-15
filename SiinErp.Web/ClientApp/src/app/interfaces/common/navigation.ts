export interface Navigation {
    displayName: string;
    disabled?: boolean;
    iconName: string;
    route?: string;
    children?: Navigation[];
}