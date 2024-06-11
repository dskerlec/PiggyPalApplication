import { CategoryEnum } from "../enums/categoryId.enum";


export function getCategoryName(categoryId: number): string {
    return CategoryEnum[categoryId] || 'Unknown';
  }