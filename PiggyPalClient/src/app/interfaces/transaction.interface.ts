export interface ITransaction {
    transactionId: number;
    transactionDate: Date;
    transactionAmount: number;
    categoryId: number;
    transactionDescription: string;
    userId: number;
}