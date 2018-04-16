using Data.Records;
using System.Collections.Generic;

namespace Core.Tests.Mock
{
    public class MockDataContext
    {
        public List<SortTypeRecord> SortTypeRecord
        {
            get
            {
                return new List<SortTypeRecord>
                {
                    new SortTypeRecord
                    {
                        Id = 1,
                        Name = "Unordered"
                    },
                    new SortTypeRecord
                    {
                        Id = 2,
                        Name = "Ascending"
                    },
                    new SortTypeRecord
                    {
                        Id = 3,
                        Name = "Descending"
                    },
                };

            }
        }

        public List<ValueRecord> ValueRecord
        {
            get
            {
                return new List<ValueRecord>
                {
                    new ValueRecord
                    {
                        Id = 1,
                        Value = 66
                    },
                    new ValueRecord
                    {
                        Id = 2,
                        Value = 99
                    },
                    new ValueRecord
                    {
                        Id = 3,
                        Value = 33
                    },
                };

            }
        }

        public List<ChangeLogRecord> ChangeLogRecord
        {
            get
            {
                return new List<ChangeLogRecord>
                {
                    new ChangeLogRecord
                    {
                        Id = 12,
                        Version = 1,
                        SortType = new SortTypeRecord { Id = 2, Name = "Ascending" },
                        TimeTaken = 200,
                        Values = new List<ChangeLogValueRecord>
                        {
                            new ChangeLogValueRecord
                            {
                                Id = 1,
                                Position = 1,
                                Value = new ValueRecord
                                {
                                    Id = 3,
                                    Value = 33
                                }
                            },
                            new ChangeLogValueRecord
                            {
                                Id = 2,
                                Position = 2,
                                Value = new ValueRecord
                                {
                                    Id = 1,
                                    Value = 66
                                }
                            },
                            new ChangeLogValueRecord
                            {
                                Id = 3,
                                Position = 3,
                                Value = new ValueRecord
                                {
                                    Id = 2,
                                    Value = 99
                                }
                            }
                        }
                    },
                    new ChangeLogRecord
                    {
                        Id = 13,
                        Version = 2,
                        SortType = new SortTypeRecord { Id = 3, Name = "Descending" },
                        TimeTaken = 180,
                        Values = new List<ChangeLogValueRecord>
                        {
                            new ChangeLogValueRecord
                            {
                                Id = 4,
                                Position = 1,
                                Value = new ValueRecord
                                {
                                    Id = 2,
                                    Value = 99
                                }
                            },
                            new ChangeLogValueRecord
                            {
                                Id = 5,
                                Position = 2,
                                Value = new ValueRecord
                                {
                                    Id = 1,
                                    Value = 66
                                }
                            },
                            new ChangeLogValueRecord
                            {
                                Id = 6,
                                Position = 3,
                                Value = new ValueRecord
                                {
                                    Id = 3,
                                    Value = 33
                                }
                            }
                        }
                    },
                    new ChangeLogRecord
                    {
                        Id = 13,
                        Version = 3,
                        SortType = new SortTypeRecord { Id = 2, Name = "Ascending" },
                        TimeTaken = 100,
                        Values = new List<ChangeLogValueRecord>
                        {
                            new ChangeLogValueRecord
                            {
                                Id = 7,
                                Position = 1,
                                Value = new ValueRecord
                                {
                                    Id = 3,
                                    Value = 33
                                }
                            },
                            new ChangeLogValueRecord
                            {
                                Id = 8,
                                Position = 2,
                                Value = new ValueRecord
                                {
                                    Id = 1,
                                    Value = 66
                                }
                            },
                            new ChangeLogValueRecord
                            {
                                Id = 9,
                                Position = 3,
                                Value = new ValueRecord
                                {
                                    Id = 2,
                                    Value = 99
                                }
                            }
                        }
                    },
                };
            }
        }
    }
}
