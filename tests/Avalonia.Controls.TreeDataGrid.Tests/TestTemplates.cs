﻿using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Templates;
using Avalonia.Layout;
using Avalonia.Styling;

namespace Avalonia.Controls.TreeDataGridTests
{
    internal static class TestTemplates
    {
        public static ControlTemplate ScrollViewerTemplate()
        {
            return new FuncControlTemplate<ScrollViewer>((x, ns) =>
                new Grid
                {
                    ColumnDefinitions = new ColumnDefinitions
                    {
                        new ColumnDefinition(1, GridUnitType.Star),
                        new ColumnDefinition(GridLength.Auto),
                    },
                    RowDefinitions = new RowDefinitions
                    {
                        new RowDefinition(1, GridUnitType.Star),
                        new RowDefinition(GridLength.Auto),
                    },
                    Children =
                    {
                        new ScrollContentPresenter
                        {
                            Name = "PART_ContentPresenter",
                            [~ContentPresenter.ContentProperty] = x[~ContentControl.ContentProperty],
                            [~~ScrollContentPresenter.ExtentProperty] = x[~~ScrollViewer.ExtentProperty],
                            [~~ScrollContentPresenter.OffsetProperty] = x[~~ScrollViewer.OffsetProperty],
                            [~~ScrollContentPresenter.ViewportProperty] = x[~~ScrollViewer.ViewportProperty],
                            [~ScrollContentPresenter.CanHorizontallyScrollProperty] = x[~ScrollViewer.CanHorizontallyScrollProperty],
                            [~ScrollContentPresenter.CanVerticallyScrollProperty] = x[~ScrollViewer.CanVerticallyScrollProperty],
                        }.RegisterInNameScope(ns),
                        new ScrollBar
                        {
                            Name = "horizontalScrollBar",
                            Orientation = Orientation.Horizontal,
                            [~RangeBase.MaximumProperty] = x[~ScrollViewer.HorizontalScrollBarMaximumProperty],
                            [~~RangeBase.ValueProperty] = x[~~ScrollViewer.HorizontalScrollBarValueProperty],
                            [~ScrollBar.ViewportSizeProperty] = x[~ScrollViewer.HorizontalScrollBarViewportSizeProperty],
                            [~ScrollBar.VisibilityProperty] = x[~ScrollViewer.HorizontalScrollBarVisibilityProperty],
                            [Grid.RowProperty] = 1,
                        }.RegisterInNameScope(ns),
                        new ScrollBar
                        {
                            Name = "verticalScrollBar",
                            Orientation = Orientation.Vertical,
                            [~RangeBase.MaximumProperty] = x[~ScrollViewer.VerticalScrollBarMaximumProperty],
                            [~~RangeBase.ValueProperty] = x[~~ScrollViewer.VerticalScrollBarValueProperty],
                            [~ScrollBar.ViewportSizeProperty] = x[~ScrollViewer.VerticalScrollBarViewportSizeProperty],
                            [~ScrollBar.VisibilityProperty] = x[~ScrollViewer.VerticalScrollBarVisibilityProperty],
                            [Grid.ColumnProperty] = 1,
                        }.RegisterInNameScope(ns),
                    }
                });
        }

        public static Style ScrollViewerStyle => new Style(x => x.OfType<ScrollViewer>())
        {
            Setters = { new Setter(TemplatedControl.TemplateProperty, ScrollViewerTemplate()) }
        };

        public static ControlTemplate TreeDataGridTemplate()
        {
            return new FuncControlTemplate<TreeDataGrid>((x, ns) =>
                new DockPanel
                {
                    Children =
                    {
                        new TreeDataGridColumnHeadersPresenter
                        {
                            Name = "PART_ColumnHeadersPresenter",
                            [DockPanel.DockProperty] = Dock.Top,
                            [!TreeDataGridColumnHeadersPresenter.ElementFactoryProperty] = x[!TreeDataGrid.ElementFactoryProperty],
                            [!TreeDataGridColumnHeadersPresenter.ItemsProperty] = x[!TreeDataGrid.ColumnsProperty],
                        }.RegisterInNameScope(ns),
                        new ScrollViewer
                        {
                            Name = "PART_ScrollViewer",
                            Template = ScrollViewerTemplate(),
                            HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                            Content = new TreeDataGridRowsPresenter
                            {
                                Name = "PART_RowsPresenter",
                                [!TreeDataGridRowsPresenter.ColumnsProperty] = x[!TreeDataGrid.ColumnsProperty],
                                [!TreeDataGridRowsPresenter.ElementFactoryProperty] = x[!TreeDataGrid.ElementFactoryProperty],
                                [!TreeDataGridRowsPresenter.ItemsProperty] = x[!TreeDataGrid.RowsProperty],
                                [!TreeDataGridRowsPresenter.SelectionProperty] = x[!TreeDataGrid.SelectionInteractionProperty],
                            }.RegisterInNameScope(ns),
                        }.RegisterInNameScope(ns)
                    }
                });
        }

        public static Style TreeDataGridStyle => new Style(x => x.OfType<TreeDataGrid>())
        {
            Setters = { new Setter(TemplatedControl.TemplateProperty, TreeDataGridTemplate()) }
        };

        public static ControlTemplate TreeDataGridRowTemplate()
        {
            return new FuncControlTemplate<TreeDataGridRow>((x, ns) =>
                new DockPanel
                {
                    Children =
                    {
                        new TreeDataGridCellsPresenter
                        {
                            Name = "PART_CellsPresenter",
                            [!TreeDataGridCellsPresenter.ElementFactoryProperty] = x[!TreeDataGridRow.ElementFactoryProperty],
                            [!TreeDataGridCellsPresenter.ItemsProperty] = x[!TreeDataGridRow.ColumnsProperty],
                            [!TreeDataGridCellsPresenter.RowsProperty] = x[!TreeDataGridRow.RowsProperty],
                        }.RegisterInNameScope(ns),
                    }
                });
        }

        public static Style TreeDataGridRowStyle => new Style(x => x.OfType<TreeDataGridRow>())
        {
            Setters = { new Setter(TemplatedControl.TemplateProperty, TreeDataGridRowTemplate()) }
        };

        public static ControlTemplate TreeDataGridExpanderCellTemplate()
        {
            return new FuncControlTemplate<TreeDataGridExpanderCell>((x, ns) =>
                new DockPanel
                {
                    Children =
                    {
                        new DockPanel
                        {
                            Children =
                            {
                                new ToggleButton
                                {
                                    [!!ToggleButton.IsCheckedProperty] = x[!!TreeDataGridExpanderCell.IsExpandedProperty],
                                },
                                new Decorator
                                {
                                    Name = "PART_Content",
                                }.RegisterInNameScope(ns),
                            }
                        },
                    }
                });
        }

        public static Style TreeDataGridExpanderCellStyle => new Style(x => x.OfType<TreeDataGridExpanderCell>())
        {
            Setters = { new Setter(TemplatedControl.TemplateProperty, TreeDataGridExpanderCellTemplate()) }
        };

        public static ControlTemplate TreeDataGridTemplateCellTemplate()
        {
            return new FuncControlTemplate<TreeDataGridTemplateCell>((x, ns) =>
                new ContentPresenter
                {
                    Name = "PART_ContentPresenter",
                    [~ContentPresenter.ContentProperty] = x[~TreeDataGridTemplateCell.ContentProperty],
                    [~ContentPresenter.ContentTemplateProperty] = x[~TreeDataGridTemplateCell.ContentTemplateProperty],
                });
        }

        public static Style TreeDataGridTemplateCellStyle => new Style(x => x.OfType<TreeDataGridTemplateCell>())
        {
            Setters = { new Setter(TemplatedControl.TemplateProperty, TreeDataGridTemplateCellTemplate()) }
        };
    }
}
