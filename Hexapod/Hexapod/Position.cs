namespace Hexapod
{
    public class Position
    {
        public double Time { get; set; }
        public double X0 { get; set; }
        public double Y0 { get; set; }
        public double Z0 { get; set; }
        public double Fi { get; set; }
        public double Theta { get; set; }
        public double Psi { get; set; }
        public Point G { get; set; }
        public Point H { get; set; }
        public Point I { get; set; }
        public Point J { get; set; }
        public Point K { get; set; }
        public Point L { get; set; }
        public double Rail1Length { get; set; }
        public double Rail2Length { get; set; }
        public double Rail3Length { get; set; }
        public double Rail4Length { get; set; }
        public double Rail5Length { get; set; }
        public double Rail6Length { get; set; }
    }
}
